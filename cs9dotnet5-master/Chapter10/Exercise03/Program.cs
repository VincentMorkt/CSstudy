﻿using System.Collections.Generic;
using System.IO;
using System.Xml;
using Packt.Shared;
using static System.Console;
using static System.IO.Path;
using static System.Environment;
using System.Security.Cryptography;

namespace Exercise03
{
  class Program
  {
    static void Main(string[] args)
    {
      WriteLine("You must enter the correct password to decrypt the document.");
      Write("Password: ");
      string password = ReadLine();

      var customers = new List<Customer>();

      // define an XML file to read from
      string xmlFile = Combine(CurrentDirectory,
        "..", "protected-customers.xml");

      if (!File.Exists(xmlFile))
      {
        WriteLine($"{xmlFile} does not exist!");
        return;
      }

      var xmlReader = XmlReader.Create(xmlFile,
        new XmlReaderSettings { IgnoreWhitespace = true });

      while (xmlReader.Read())
      {
        if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "customer")
        {
          xmlReader.Read(); // move to <name>
          string name = xmlReader.ReadElementContentAsString();
          string creditcardEncrypted = xmlReader.ReadElementContentAsString();
          string creditcard = null;
          string errorMessage = null;
          try
          {
            creditcard = Protector.Decrypt(creditcardEncrypted, password);
          }
          catch (CryptographicException)
          {
            errorMessage = $"Failed to decrypt {name}'s credit card.";
          }
          string passwordHashed = xmlReader.ReadElementContentAsString();
          string salt = xmlReader.ReadElementContentAsString();

          customers.Add(new Customer
          {
            Name = name,
            CreditCard = creditcard ?? errorMessage,
            Password = passwordHashed,
            Salt = salt
          });
        }
      }

      xmlReader.Close();

      WriteLine();
      int number = 0;
      WriteLine("    {0,-20} {1,-20}",
        arg0: "Name",
        arg1: "Credit Card");

      foreach (var customer in customers)
      {
        WriteLine("[{0}] {1,-20} {2,-20}",
          arg0: number,
          arg1: customer.Name,
          arg2: customer.CreditCard);

        number++;
      }
      WriteLine();

      Write("Press the number of a customer to log in as: ");

      string customerName = null;
      try
      {
        number = int.Parse(ReadKey().KeyChar.ToString());
        customerName = customers[number].Name;
      }
      catch
      {
        WriteLine();
        WriteLine("Not a valid customer selection.");
        return;
      }

      WriteLine();
      Write($"Enter {customerName}'s password: ");

      string attemptPassword = ReadLine();

      if (Protector.CheckPassword(
        username: customers[number].Name, 
        password: attemptPassword,
        salt: customers[number].Salt, 
        hashedPassword: customers[number].Password))
      {
        WriteLine("Correct!");
      }
      else
      {
        WriteLine("Wrong!");
      }
    }
  }
}
// See https://aka.ms/new-console-template for more information
using Hexalith.Shift.Domain.Facade;

var message = new FormatableText("Hello %1 %2", new object[] { "Jérôme", "Piquot" });
Console.WriteLine(message);
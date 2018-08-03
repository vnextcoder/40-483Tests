using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
namespace LinqtoXML
{
    class Program
    {
        static XDocument CreateXMLDocument()
        {
            XDocument clientDoc = new XDocument();
            clientDoc.Declaration = new XDeclaration("1.0", "utf-8", "no");

            XElement clients = new XElement("Clients");
            clients.Add(new XElement("Client",
                new XAttribute("ID","AMEX"),
                new XElement ("Name","American Express"),
                new XElement("Location","USA")));

            clients.Add(new XElement("Client",
                new XAttribute("ID", "ACL"),
                new XElement("Name", "Accenture Limited"),
                new XElement("Location", "India")));
            clientDoc.Add(clients);
            clientDoc.Save("createddoc.xml");
            return clientDoc;
        
        }
        static void Main(string[] args)
        {
            XDocument doc2 = CreateXMLDocument();
            XDocument projectsDoc = XDocument.Load("Projects.xml");


            #region Requirement-1
            //Display all ITT Projects
            //var projects=projectsDoc.Descendants("Project").Where(p=> p.Element("Description").Value.Contains("ITT"));
            //same as above
            //var projects = from p in projectsDoc.Descendants("Project")
            //               where p.Element("Description").Value.Contains("AXA")
            //               orderby p.Element("TeamSize").Value descending
            //               select p;


            //var projects = from p in projectsDoc.Descendants("Project")
            //               where Convert.ToInt32(p.Element("TeamSize").Value) > 2
            //               select p;
            #endregion


            #region Requirement-2
                //Display all projects whose duration range is 200-600
            //var projects = from p in projectsDoc.Descendants("Project")
            //               where Convert.ToInt32(p.Element("Duration").Value) > 200
            //                    && Convert.ToInt32(p.Element("Duration").Value) <600
            //                    select p;

            //var projects = projectsDoc.Descendants("Project")
            //    .Where(p =>
            //        {
            //            int duration = Convert.ToInt32(p.Element("Duration").Value);
            //            return duration >= 200 && duration <= 600;

            //                  }
            //               select p;
            #endregion

            #region Get all projects of India

            //var projects = from p in projectsDoc.Descendants("Project")
            //               where p.Element("Location").Element("Country").Value == "India"
            //               select p;


            var projects = ( projectsDoc.Descendants("Location")
                           .Where (p=> p.Element("Country").Value == "India"))
                           .Ancestors("Project");
 
            #endregion

            #region MyRegion
            
            #endregion

            foreach (var item in projects)
	        {
		        Console.WriteLine(item);
            }
            Console.ReadKey();
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace HallmarkCSharp
{
    // Every class requires two things to make it an attribute. 
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public class CustomAttribute : Attribute
    {
        public CustomAttribute(string label, ConsoleColor color = ConsoleColor.Green)
        {
           
            Label = label ?? throw new ArgumentNullException(nameof(label));
            Color = color;
        }
        
        public string Label { get; }
        public bool IsValid { get; }
        public ConsoleColor Color { get; }
        
        public static void WriteEachMethodInClass(Type t) // method of the Stereotype class
        {
            PropertyInfo propNameWhereAttributeApplied = typeof(Subject).GetProperty(nameof(Subject.SubjectId));
            
            System.Console.WriteLine("Methods for Class {0}", t.Name); // write class name to console
            MethodInfo[] theMethods = t.GetMethods(); // Get all the methods from the class using reflection
            
            for (int i = 0; i < theMethods.GetLength(0); i++) // cycle through each method and see if it has an attribute
            {
                MethodInfo mi = theMethods[i];
                IEnumerable<Attribute> attrs = mi.GetCustomAttributes(); // Get collection of custom attributes from the method
                foreach (Attribute attr in attrs) // get each attribute using foreach
                {
                    if (attr is CustomAttribute) // is the attribute a Stereotype Attribute?
                    {
                        CustomAttribute theStereotype = (CustomAttribute)attr; // it is, write the Stereotype and the Description to the console
                        System.Console.WriteLine("{0} - {1}, {2}", mi.Name, theStereotype.Label, theStereotype.Color);
                    } 
                }
            }
            
            ConstructorInfo[] theConstructors = t.GetConstructors (); // do the same for the constructors of our class
            for (int i = 0; i < theConstructors.GetLength(0); i++)
            { 
                ConstructorInfo mi = theConstructors[i];
                IEnumerable<Attribute> attrs = mi.GetCustomAttributes(); 
                foreach (Attribute attr in attrs)
                {
                    if (attr is CustomAttribute)
                    {
                        CustomAttribute theStereotype = (CustomAttribute)attr;
                        System.Console.WriteLine("{0} - {1},{2}", mi.Name, theStereotype.Label, theStereotype.Color);
                    }
                }
            }
        } 
    }
}
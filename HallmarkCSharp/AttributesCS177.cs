using System;
using System.Reflection;

namespace HallmarkCSharp
{
    public class AttributesCS177
    {
        public static void Start()
        {
            /*using reflection for access attribute*/

            //PropertyInfo propNameWhereAttributeApplied = typeof(Subject).GetProperty(nameof(Subject.SubjectId));
            //CustomAttribute ca = (CustomAttribute) Attribute.GetCustomAttribute(propNameWhereAttributeApplied, typeof(CustomAttribute));
            //var id = ca.Label + subject.SubjectId;

            //Console.ForegroundColor = ca.Color;
            //Console.WriteLine(id);
            
            Subject subject = new Subject();
            var desc = subject.SubjectDescription;
            
            CustomAttribute.WriteEachMethodInClass(typeof(Subject));
        }
    }
}
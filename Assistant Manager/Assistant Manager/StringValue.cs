using System;
namespace Assistant_Manager
{
    public class StringValue : Attribute
    {
        private string m_Str;

        public StringValue(string Value)
        {
            this.m_Str = Value;
        }

        public string GetStr()
        {
            return this.m_Str;
        }

        public static string GetStringValue(WorkType Val)
        {
            string str = null;
            StringValue[] customAttributes = Val.GetType().GetField(Val.ToString()).GetCustomAttributes(typeof(StringValue), false) as StringValue[];
            if (customAttributes.Length > 0)
            {
                str = customAttributes[0].GetStr();
            }
            return str;
        }
    }
}

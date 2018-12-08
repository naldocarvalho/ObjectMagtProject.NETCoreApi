using System;
using System.Collections.Generic;
using System.Reflection;

namespace OpenText.ProjectApi.Models
{
    public class SysObjectEntity
    {
        private readonly int id;       
        public int Id { get { return this.id; } }
        public string propertyname { get; set; }
       
        public dynamic UserObject; 

        public SysObjectEntity(dynamic obj, string title, int id)
        {
            this.UserObject = obj;
            this.id = id;
            this.propertyname = title;
        }

        public List<string> GetAllMembers()
        {
             List<string> myMemberInfo = new List<string>();
             
          // Get the type of this class
          Type myType = this.GetType();


            // Get the information related to all public member's . 
            MemberInfo[] resultM= myType.GetMembers();
            PropertyInfo[] resultP = myType.GetProperties();
            FieldInfo[] resultF = myType.GetFields();


            myMemberInfo.Add("Here are the objects properties and their values :");
            for (int i = 0; i < resultP.Length; i++)
            {
                // Display name and value of the concerned member.               
                myMemberInfo.Add(resultP[i].Name + "            Value =" + resultP[i].GetValue(this));
            }

            myMemberInfo.Add("================================================");

            myMemberInfo.Add("Here are the objects fields and their values :");

            // FieldInfo[] fields = typeof(<class>).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            for (int i= 0; i < resultF.Length; i++)
            {
                // Display name and value of the concerned member.               
                myMemberInfo.Add(resultF[i].Name + "            Value =" + resultF[i].GetValue(this));
            }

                    myMemberInfo.Add("================================================");

                    myMemberInfo.Add("Here are the objects members and their types :");

            for (int i = 0; i < resultM.Length; i++)
            {               
                // Display name and type of the concerned member.
                myMemberInfo.Add(resultM[i].Name + "            Type = " + resultM[i].GetType());              
            }           
           
            return myMemberInfo;
        }

        public object GetpropertynameValue(string str)
        {
            object result = "The propperty with name  " +str + " does not exist on this object.";
            List<string> myMemberInfo = new List<string>();

            // Get the type of this class
            Type myType = this.GetType();

            // Get the information related to all public member's .            
            PropertyInfo[] resultP = myType.GetProperties();

            for (int i = 0; i < resultP.Length; i++)
            {
                if (resultP[i].Name == str)
                {
                    result = resultP[i].GetValue(this);                     
                }
            }            
            return result;
        }

        public void SetpropertynameValue(string propertyname, string newValue)
        {
            string result = null;
            List<string> myMemberInfo = new List<string>();

            // Get the type of this class
            Type myType = this.GetType();

            // Get the properties         
            PropertyInfo[] resultP = myType.GetProperties();

            for (int i = 0; i < resultP.Length; i++)
            {
                if (resultP[i].Name == propertyname)
                {
                    result = resultP[i].Name;
                    myType.GetProperty(result).SetValue(this, newValue);
                }
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace API_Example
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Set credential values
            string sourcename = "YourSourceName";
            string password = "YourPassword";
            int[] siteIDs = {-99};

            // Setup Service
            ClassService.ClassService service = new ClassService.ClassService();

            // Create and fill request
            ClassService.GetClassesRequest request = new ClassService.GetClassesRequest();

            request.SourceCredentials = new ClassService.SourceCredentials();
            request.SourceCredentials.SourceName = sourcename;
            request.SourceCredentials.Password = password;
            request.SourceCredentials.SiteIDs = siteIDs;

            //Run call with request and fill result  
            ClassService.GetClassesResult result = service.GetClasses(request);
            
            //Display result in label
            foreach(ClassService.Class thisClass in result.Classes)
            {
                Classes.Text += "<br/>______________________________________<div><p>" + 
                    thisClass.ClassDescription.Name + "</p>" +
                    "<p>" + thisClass.ID + "</p>" +
                    "<p>" + thisClass.EndDateTime + " - " + thisClass.EndDateTime + "</p>" +
                    "<p>" + thisClass.ClassDescription.Description + "</p></div>";
            }
        }
    }
}

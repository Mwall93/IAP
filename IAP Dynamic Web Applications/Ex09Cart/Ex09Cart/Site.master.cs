using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site : System.Web.UI.MasterPage
{
    public string PageH1Text
    {
        set { lblH1.Text = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //fill 'Days Until' label if it hasn't been overridden
       // if (lblDaysUntilHalloween != null)
        //{
            //int daysUntil = DaysUntilHalloween();
            //switch (daysUntil)
            //{
            //    case 0:
            //        lblDaysUntilHalloween.Text = "Happy Halloween!";
            //        break;
            //    case 1:
            //        lblDaysUntilHalloween.Text = "Tomorrow is Halloween!";
            //        break;
            //    default:
            //        lblDaysUntilHalloween.Text = string.Format(
            //            "There are only {0} days left until Halloween!", daysUntil);
            //        break;
            //}
            //Add Appropriate Footer, Saying when open? (Edit DaysUntilHalloween to display open times)
            //lblDaysUntilHalloween.Text = string.Format("Appropriate Footer Here");
       // }
    }

    private int DaysUntilHalloween()
    {
        DateTime halloween = new DateTime(DateTime.Today.Year, 10, 31);
        if (DateTime.Today > halloween)
            halloween = halloween.AddYears(1);
        TimeSpan ts = halloween - DateTime.Today;
        return ts.Days;
    }
}

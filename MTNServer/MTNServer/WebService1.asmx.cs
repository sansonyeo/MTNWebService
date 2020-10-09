using System.Web.Services;
using System.Data;

namespace MTNServer
{
    /// <summary>
    /// WebService1의 요약 설명입니다.
    /// </summary>
    [WebService(Namespace = "http://mtngirl.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    
    // ASP.NET AJAX를 사용하여 스크립트에서 이 웹 서비스를 호출하려면 다음 줄의 주석 처리를 제거합니다. 
    // [System.Web.Script.Services.ScriptService]

    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable SelectCertificates(string certs_drive)
        {
            return DAL.SelectCertificates(certs_drive);
        }
        [WebMethod]
        public bool[] InsertCertificates(Certificate[] list)
        {
            return DAL.InsertCertificates(list);
        }

    }
}

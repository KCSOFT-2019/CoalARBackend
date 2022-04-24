namespace AR_EduOre_api.Helpers;

public class UserUtil
{
   public static Guid getUserId(HttpContext httpContext)
   {
      if (httpContext != null)
      {
         return new Guid(httpContext.User.Claims.FirstOrDefault(c => c.Type == "sid").Value);
      }

      throw new Exception("[UserUtil]no httpcontext");

   }
}
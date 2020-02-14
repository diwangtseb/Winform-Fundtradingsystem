using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Fundtradingsystem
{
    ///<summary>
    ///
    ///</summary>
    public partial class Users
    {
           public Users(){


           }
           /// <summary>
           /// Desc:
           /// Default:newid()
           /// Nullable:False
           /// </summary>
           [SugarColumn(IsPrimaryKey = true,IsIdentity = true)] 
           public Guid Id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Phonenum {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Password {get;set;}

           /// <summary>
           /// Desc:
           /// Default:DateTime.Now
           /// Nullable:False
           /// </summary>           
           public DateTime Createtime {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Nicky {get;set;}

    }
}

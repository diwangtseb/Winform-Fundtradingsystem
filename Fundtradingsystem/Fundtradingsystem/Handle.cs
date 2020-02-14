using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Fundtradingsystem
{
    ///<summary>
    ///
    ///</summary>
    public partial class Handle
    {
           public Handle(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(IsPrimaryKey = true,IsIdentity = true)] 
           public Guid Id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Afactory {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Bfactory {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Cfactory {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Dfactory {get;set;}

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolmanagement.Domain.Enums
{
    public enum Grades
    {
        [Range(95,100)]
        AP ,

        [Range(90,94)]
        A,

        [Range(85,89)]
        AM,

        [Range(80,84)]
        BP,

        [Range(75,79)]
        B,

        [Range(70,74)]
        CP,

        [Range(65,69)]
        C,

        [Range(60,64)]
        DP,

        [Range(55,59)]
        D,
        
        [Range(50,54)]
        DM,

        [Range(0,49)]
        F

    }
}

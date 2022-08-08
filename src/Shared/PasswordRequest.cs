using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class PasswordRequest
    {
        public bool Uppercase { get; set; }
        public bool Lowercase { get; set; }
        public bool Numbers { get; set; }
        public bool SpecialCharacters { get; set; }
        public int Length { get; set; }
    }
}

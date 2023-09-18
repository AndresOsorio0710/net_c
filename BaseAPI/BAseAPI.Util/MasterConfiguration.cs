using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BaseAPI.Entities.Models;
using System.Reflection;

namespace BaseAPI.Util
{
    public class MasterConfiguration:MasterBase
    {

        public Cryptography cryptography { get; set; }

        private void Cryptography()
        {
            cryptography = new Cryptography();
            cryptography.Clave = this.configuration["Cryptography:Clave"];
            cryptography.Hex = this.configuration["Cryptography:Hex"];
        }

        public MasterConfiguration()
        {
            Cryptography();
        }

    }
}

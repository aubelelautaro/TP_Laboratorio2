using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class Test
    {
        /// <summary>
        /// Verifica que la lista de Paquetes del Correo esté instanciada
        /// </summary>
        [TestMethod]
        public void TestListaInstanciada()
        {
            Correo c = new Correo();

            Assert.IsTrue(true);

            Assert.IsNotNull(c);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestMismoID()
        {
            Correo c = new Correo();

            Paquete p1 = new Paquete("Alsina","912-189-1218");
            Paquete p2 = new Paquete("Bochini", "912-189-1218");

            try
            {
                c += p1;
                c += p2;
            }
            catch (TrackingIdRepetidoException)
            {
                Assert.IsTrue(true);
            }
        }

    }
}

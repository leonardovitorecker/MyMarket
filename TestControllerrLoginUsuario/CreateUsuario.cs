using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMarket.Controllers;
using MyMarket.Database;
using MyMarket.Helper;
using MyMarket.Models;
using System;

namespace TestControllerrLoginUsuario
{






    [TestClass]
    public class CreateUsuario
    {
        public string senha = null;
        [TestMethod]
        public void TestCreateUsuario()
        {
            senha = "12";
            var usuario = new Usuario();
            Assert.AreEqual(false, usuario.validSenha(senha));

            senha = "123";
            Assert.AreEqual(false, usuario.SenhaValida(senha));

        }
    }
}
using ClaySmartLock.Service.Imp;
using ClaySmartLock.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClaySmartLock.Test.Service
{
    public class HashServiceTest
    {
        private readonly IHashService _hashService;

        public HashServiceTest()
        {
            _hashService = new HashService();
        }

        [Fact]
        public void HashBySha512_NotNullNotEmptyResult()
        {
            var result = _hashService.HashBySha512("test");
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void HashBySha512_NullResult()
        {
            var result = _hashService.HashBySha512(null);
            Assert.Null(result);
        }
    }
}

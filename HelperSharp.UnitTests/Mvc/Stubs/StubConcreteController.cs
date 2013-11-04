using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace HelperSharp.UnitTests.Mvc.Stubs
{
    class StubConcreteController : ControllerBase
    {
        protected override void ExecuteCore()
        {
            throw new NotImplementedException();
        }

        public ActionResult Index()
        {
            throw new NotImplementedException();
        }

        [Authorize]
        public ActionResult Create()
        {
            throw new NotImplementedException();
        }
    }
}

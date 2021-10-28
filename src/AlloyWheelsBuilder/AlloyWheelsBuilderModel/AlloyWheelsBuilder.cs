using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;

namespace AlloyWheelsBuilderModel
{
    public static class AlloyWheelsBuilder
    {
        private static Session _session;

        private static Part _workPart;

        public static void Build(AlloyWheelsData alloyWheelsData)
		{
            _session = Session.GetSession();

            _workPart = _session.Parts.Work;
        }
    }
}

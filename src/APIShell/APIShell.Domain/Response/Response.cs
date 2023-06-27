using System;
using System.Collections.Generic;
using System.Text;

namespace APIShell.Domain.Response
{
    public class SuccessResponse
    {
        public SuccessResponse()
        {
            success = true;
            data = null;
        }

        public bool success { get; set; }
        public string data { get; set; }
    }

    public class ModelErrorResponse
    {
        public ModelErrorResponse()
        {
            success = false;
            data = new ModelErrorDataResponse();
        }

        public bool success { get; set; }
        public ModelErrorDataResponse data { get; set; }
    }

    public class ModelErrorDataResponse
    {
        public string Key { get; set; }
        public string Erro { get; set; }
    }
}

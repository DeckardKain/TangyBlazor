﻿using Microsoft.AspNetCore.Components.Forms;
using System.Net;

namespace TangyWeb_Server.Service.IService
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file);
        bool DeleteFile(string filepath);
    }
}

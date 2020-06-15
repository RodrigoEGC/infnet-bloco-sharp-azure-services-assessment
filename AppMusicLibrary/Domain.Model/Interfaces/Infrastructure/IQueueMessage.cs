using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Infrastructure
{
    public interface IQueueMessage
    {
        Task SendAsync(string messageText);
        Task DeleteAsync(string messageText);
    }
}

using DemoDomain.Interfaces;
using DemoDomain.Models;
using MassTransit;

namespace DemoServices.Services;

public class MessageService : IMessageService
{
  private IBus messageBus;

  public MessageService(IBus messageBus)
  {
    this.messageBus = messageBus;
  }

  public void SendMessage(string message)
  {
    var msg = new Message(message);

    messageBus.Publish<Message>(message);
  }
}

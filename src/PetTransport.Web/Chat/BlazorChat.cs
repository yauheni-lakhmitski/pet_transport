using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PetTransport.Domain.Entities;
using PetTransport.Infrastructure.Data;

namespace PetTransport.Web.Chat;

public class BlazorChatSampleHub : Hub
{
    private readonly ApplicationDbContext _context;

    public BlazorChatSampleHub(ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    
    public const string HubUrl = "/chat";

    public async Task Broadcast(string username, string tripId, string message)
    {
        await Clients.All.SendAsync("Broadcast", username, message);
    }

    public override Task OnConnectedAsync()
    {
        Console.WriteLine($"{Context.ConnectionId} connected");
        return base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception e)
    {
        Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
        await base.OnDisconnectedAsync(e);
    }
    
    
    
    public async Task Send(string userName, string tripId, string message)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x=>x.UserName==userName);
            
        //  if (string.IsNullOrEmpty(messageDto.Text))
        //      return;
        //
        var trip = _context.Rides.Include(s=>s.Messages).FirstOrDefault(s => s.Id == Guid.Parse(tripId));

        var messages = trip.Messages.ToList();
        var newMessage = new Message()
        {
            RideId = Guid.Parse(tripId),
            UserId = user.Id,
            Text = message,
            CreatedAt = DateTime.Now,
            Ride = trip,
            User = user
        };
        trip.Messages.Add(newMessage);
        
        _context.Update(trip);
           
        await _context.SaveChangesAsync();

        await Clients.All.SendAsync("Broadcast", $"{newMessage.User.UserName}",$"{user.FirstName} {user.LastName}", message);
    }
        

    public async Task Start(string tripId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, tripId);
    }
}
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

public class IntergrationTest1 : IClassFixture<UseInMemoryDbFactory>
{
    private readonly HttpClient _client;
    public IntergrationTest1(UseInMemoryDbFactory factory)
    {
        _client = factory.CreateClient();
    }
    [Fact]
    public async Task Should_Return_200()
    {
        var act = await _client.GetAsync("/api/OrderApi/AllOrders");
        Assert.Equal(HttpStatusCode.OK, act.StatusCode);
    }
}
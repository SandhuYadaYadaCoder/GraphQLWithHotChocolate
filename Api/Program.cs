using Api.GraphQL;
using Application;
using Core;
using DataAccess;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console());

builder.Services
    .RegisterCore()
    .RegisterDataAccess(builder.Configuration.GetConnectionString("CommandConStr"))
    .RegisterApplication()
    .RegisterGraphQL();

var app = builder.Build();

app.Services.UpdateDatabase(Log.Logger);

app.MapGraphQL();

app.UseWebSockets();

app.UseGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
});

//test

app.Run();

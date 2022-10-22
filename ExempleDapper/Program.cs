using ExempleDapper.ConnectionContext;
using ExempleDapper.Interfaces;
using ExempleDapper.Respository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<SqlConnectionContext>();
builder.Services.AddScoped<IHomeland, HomelandRepository>(); // New Add
builder.Services.AddScoped<IThailandPost, ThailandPostRespo>(); // New Add
builder.Services.AddScoped<IUsers, UserRepository>();
builder.Services.AddScoped<IUserRole, UserRoleRepository>();
builder.Services.AddScoped<IStatus, StatusRepository>();
builder.Services.AddControllers();

//���� Policy �����
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// �Ӥѭ��ͧ������ӴѺ
//�������� Policy���� ��ͧ���¡�� 
app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

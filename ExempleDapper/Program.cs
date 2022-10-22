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

//เพิ่ม Policy เข้ามา
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

// สำคัญต้องใส่ตามลำดับ
//เมื่อใส่ Policyแล้ว ต้องเรียกใช้ 
app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

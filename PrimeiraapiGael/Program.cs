// 1. O 'builder' é o construtor. Ele prepara as ferramentas que a API vai usar.
var builder = WebApplication.CreateBuilder(args);

// Adiciona o suporte para Controladores (o padrão MVC). 
// analogia: Isso permite que a API tenha 'garçons' para receber os pedidos.
builder.Services.AddControllers();

// Prepara o sistema para entender onde os endereços (endpoints) da API estão.
builder.Services.AddEndpointsApiExplorer();

// onde testamos a API.
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

// 2. O 'app' é a API pronta. O builder termina a construção aqui.
var app = builder.Build();

// --- ATENDIMENTO (Regras da API rodando) ---

// Verifica se estamos no modo de desenvolvimento (estudando/programando).
if (app.Environment.IsDevelopment())
{
    // Liga o Swagger para conseguir ver a interface visual no navegador.
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redireciona chamadas inseguras para o modo seguro (HTTPS) com cadeado.
app.UseHttpsRedirection();

// Gerencia quem tem permissão para acessar a API (segurança).
app.UseAuthorization();

app.MapHealthChecks("/health");

// Cria o mapa que liga o que digitamos na URL aos nossos Controllers.
app.MapControllers();

// 3. Dá o 'Play'! A API começa a escutar os pedidos a partir de agora.
app.Run();
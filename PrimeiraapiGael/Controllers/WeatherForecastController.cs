// Diretiva using que permite o uso de classes e atributos do framework ASP.NET Core MVC.
using Microsoft.AspNetCore.Mvc;

// Definição do Namespace, utilizado para organizar logicamente o escopo das classes e evitar conflitos de nomes.
namespace PrimeiraapiGael.Controllers
{
    // Atributo que decora a classe para habilitar comportamentos específicos de API, como validação automática de modelos.
    [ApiController]
    // Atributo de roteamento que define o padrão de URL da API; [controller] assume o nome da classe sem o sufixo 'Controller'.
    [Route("[controller]")]
    // Definição de uma classe pública que herda de ControllerBase, a classe base para controladores de API sem suporte a Views.
    public class WeatherForecastController : ControllerBase
    {
        // Declaração de um campo privado, estático e somente leitura (imutável após inicialização) do tipo array de strings.
        private static readonly string[] Summaries = new[]
        {
            "Arthur", "Cíntia", "Arroz", "Feijão", "Anderson", "Macarrrão", "Luísa"
        };

        // Campo privado e somente leitura para armazenar a instância do serviço de log via Injeção de Dependência.
        private readonly ILogger<WeatherForecastController> _logger;

        // Método Construtor da classe, que recebe uma instância de ILogger através da Injeção de Dependência do ASP.NET Core.
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            // Atribuição da instância recebida ao campo privado da classe.
            _logger = logger;
        }

        // Atributo que define que este método responde a requisições HTTP do tipo GET e define um nome para a rota.
        [HttpGet(Name = "GetWeatherForecast")]

        // Método público que retorna uma coleção do tipo IEnumerable contendo objetos da classe WeatherForecast.
        public IEnumerable<WeatherForecast> Get()
        {
            // Utilização de LINQ (Language Integrated Query) para gerar uma sequência e projetar novos objetos.
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                // Atribuição da propriedade Date com a data atual acrescida do índice do loop.
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                // Atribuição de um valor inteiro aleatório entre -20 e 55 à propriedade TemperatureC.
                TemperatureC = Random.Shared.Next(-20, 55),
                // Atribuição de um valor à propriedade Summary selecionado aleatoriamente do array Summaries.
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            // Converte o resultado da consulta LINQ em um Array para retorno da função.
            .ToArray();
        }
    }
}
using System.Security.Cryptography.X509Certificates;

string opcao;
do
{
    Console.Clear();
    Console.WriteLine("==== Sistema de login e-CAC ====");
    Console.WriteLine("Escolha a opção desejada: ");
    Console.WriteLine("1 - Para iniciar o login via Certificado Digital A1.");
    Console.WriteLine("0 - Sair");

    opcao = Console.ReadLine();
    switch (opcao)
    {
        case "1":
            await LoginCertificadoA1Async();
            break;
        case "0":
            Console.WriteLine("Saindo do sistema...");
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}
while (opcao != "1" && opcao != "0");

Console.WriteLine("Pressione qualquer tecla para sair...");
Console.ReadKey();


/// <summary>
/// Login via certificado digital tipo A1.
/// </summary>
static async Task LoginCertificadoA1Async()
{
    try
    {
        // Caminho do arquivo .pfx 
        Console.WriteLine("Informe o caminho do seu certificado digital A1: ");
        var certificadoPath = Console.ReadLine();

        // Senha do certificado
        Console.Write("Informe a senha do certificado A1: ");
        var senhaCertificado = Console.ReadLine();

        // Carrega certificado
        var cert = new X509Certificate2(certificadoPath!, senhaCertificado);

        // Configura o HttpClientHandler para usar o certificado cliente
        var handler = new HttpClientHandler();
        handler.ClientCertificates.Add(cert);
        handler.SslProtocols = System.Security.Authentication.SslProtocols.Tls12
                               | System.Security.Authentication.SslProtocols.Tls13;

        // Habilita os cookies
        handler.UseCookies = true;

        using var client = new HttpClient(handler);

        // URL de autenticação do e-CAC para uso de certificado digital
        var urlCertDigital = "https://certificado.sso.acesso.gov.br/login";

        var response = await client.GetAsync(urlCertDigital);

        if (response.IsSuccessStatusCode)
        {
            var conteudo = await response.Content.ReadAsStringAsync();

            if (conteudo.Contains("Certificado Digital") || conteudo.Contains("conectado") || conteudo.Contains("Bem-vindo"))
            {
                Console.WriteLine("Login via certificado digital A1 realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Não foi possível confirmar o sucesso do login.");
            }
        }
        else
        {
            Console.WriteLine($"Falha ao tentar acessar URL de certificado. Status: {response.StatusCode}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao tentar login via certificado digital A1: {ex.Message}");
    }
}
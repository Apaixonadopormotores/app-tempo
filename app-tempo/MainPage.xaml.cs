namespace app_tempo;

public partial class MainPage : ContentPage
{
	Results results;
	Resposta resposta;
	const string Url="https://api.hgbrasil.com/weather?woeid=427271&key=3c51ec7f";
	public MainPage()
	{
		InitializeComponent();
	}
	async void ActualTime()
	{
		try{
			var httpClient = new HttpClient();
			var response = await httpClient.GetAsync(Url);

			if(response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();
				resposta = JsonSerializer.Deserialize<Resposta>(content);
				FIllPage();
			}
	}	
		catch(Exception e)
		{
			System.Diagnostics.Debug.WriteLine(e);
		}
	}
void FIllPage()
	{
		LabelHora.Text = resposta.results.time;
		LabelTemperatura.Text = resposta.results.temp.ToString();
		LabelCidade.Text = resposta.results.city;
		LabelTempo.Text = resposta.results.description;
		LabelChuva.Text = resposta.results.rain.ToString();
		LabelHumidade.Text = resposta.results.humidity.ToString();
		LabelForca.Text = resposta.results.wind_speedy;
		LabelDirecao.Text = resposta.results.wind_cardinal;
		LabelAmanhecer.Text = resposta.results.sunrise;
		LabelAnoitecer.Text = resposta.results.sunset;
		LabelFase.Text = resposta.results.moon_phase;
		ForecastList.ItemsSource = resposta.results.forecast;
	}
}


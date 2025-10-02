namespace TrivialGeografico;

public partial class PaisesPage : ContentPage
{
	int aciertos = 0;
	int fallos = 0;

	Dictionary<string, string> paises = new Dictionary<string, string>()
	{
		{"Madrid", "España"},
		{"París", "Francia"},
		{"Roma", "Italia"},
		{"Berlín", "Alemania"},
		{"Lisboa", "Portugal"},
		{"Londres", "Inglaterra"},
		{"Moscú", "Rusia"},
		{"Pekín", "China"},
		{"Tokio", "Japón"},
		{"Oslo", "Noruega"}
	};

    public PaisesPage()
	{
		InitializeComponent();
		Preguntar(this, EventArgs.Empty);
		aciertoLabel.Text = $"Aciertos: {aciertos}";
		falloLabel.Text = $"Fallos: {fallos}";
    }

	public void Preguntar(object? sender, EventArgs e)
	{
		var random = new Random();
		var capital = paises.ElementAt(random.Next(paises.Count));
		preguntaLabel.Text = $"¿A qué país pertenece la capital {capital.Key}?";
		// Obtén la respuesta correcta
		var respuestaCorrecta = capital.Value;
		// Obtén tres respuestas incorrectas
		var opcionesIncorrectas = paises.Values
			.Where(pais => pais != respuestaCorrecta)
			.OrderBy(_ => random.Next())
			.Take(3)
			.ToList();
		// Junta la respuesta correcta con las incorrectas y mezcla
		var opciones = opcionesIncorrectas.Append(respuestaCorrecta)
			.OrderBy(_ => random.Next())
			.ToList();
		// Asigna las opciones a los botones
		opcion1.Text = opciones[0];
		opcion2.Text = opciones[1];
		opcion3.Text = opciones[2];
		opcion4.Text = opciones[3];
    }

	public void OpcionesClicked(object? sender, EventArgs e){
		var button = (Button)sender;
		var respuesta = button.Text;
		var capital = preguntaLabel.Text.Split(' ').Last().TrimEnd('?');
        var paisCorrecto = paises[capital];
		if (respuesta == paisCorrecto)
		{
			DisplayAlert("Correcto", $"¡Has acertado! La capital {capital} pertenece a {paisCorrecto}.", "Continuar");
			aciertos++;
            aciertoLabel.Text = $"Aciertos: {aciertos}";	
		}
		else
		{
			DisplayAlert("Incorrecto", $"Has fallado. La capital {capital} pertenece a {paisCorrecto}.", "Continuar");
			fallos++;
            falloLabel.Text = $"Fallos: {fallos}";
		}

		if(aciertos + fallos >= 10)
		{
			DisplayAlert("Juego terminado", $"Has completado el juego con {aciertos} aciertos y {fallos} fallos.", "Reiniciar");
			ResetClicked(this, EventArgs.Empty);
        }
        Preguntar(this, EventArgs.Empty);
    }

	public void ResetClicked(object? sender, EventArgs e)
	{
		aciertos = 0;
		fallos = 0;
		aciertoLabel.Text = $"Aciertos: {aciertos}";
		falloLabel.Text = $"Fallos: {fallos}";
		Preguntar(this, EventArgs.Empty);
    }
}
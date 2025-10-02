namespace TrivialGeografico;

public partial class CapitalesPage : ContentPage
{
	int aciertos = 0;
	int fallos = 0;

	Dictionary<string, string> capitales = new Dictionary<string, string>()
	{
		{"Espa�a", "Madrid"},
		{"Francia", "Par�s"},
		{"Italia", "Roma"},
		{"Alemania", "Berl�n"},
		{"Portugal", "Lisboa"},
		{"Inglaterra", "Londres"},
		{"Rusia", "Mosc�"},
		{"China", "Pek�n"},
		{"Jap�n", "Tokio"},
		{"Noruega", "Oslo"},
	};

    public CapitalesPage()
	{
		InitializeComponent();
		Preguntar(this, EventArgs.Empty);
		aciertoLabel.Text = $"Aciertos: {aciertos}";
		falloLabel.Text = $"Fallos: {fallos}";
    }

	public void Preguntar(object? sender, EventArgs e)
	{
		var random = new Random();
		var pais = capitales.ElementAt(random.Next(capitales.Count));
		preguntaLabel.Text = $"�Cu�l es la capital de {pais.Key}?";

        // Obt�n la respuesta correcta
        var respuestaCorrecta = pais.Value;

        // Obt�n tres respuestas incorrectas
        var opcionesIncorrectas = capitales.Values
            .Where(capital => capital != respuestaCorrecta)
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

	public void OpcionesClicked(object? sender, EventArgs e)
	{
		var button = (Button)sender;
		var respuesta = button.Text;
		var pais = preguntaLabel.Text.Split(' ').Last().TrimEnd('?');

		if (capitales[pais] == respuesta)
		{
			DisplayAlert("Correcto", "�Has acertado!", "Siguiente");
			aciertos++;
			aciertoLabel.Text = $"Aciertos: {aciertos}";
        }
		else
		{
			DisplayAlert("Incorrecto", $"La capital de {pais} es {capitales[pais]}.", "Siguiente");
			fallos++;
			falloLabel.Text = $"Fallos: {fallos}";
        }

        if (aciertos + fallos >= 10)
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
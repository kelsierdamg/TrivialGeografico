namespace TrivialGeografico;

public partial class CapitalesPage : ContentPage
{
	Dictionary<string, string> capitales = new Dictionary<string, string>()
	{
		{"España", "Madrid"},
		{"Francia", "París"},
		{"Italia", "Roma"},
		{"Alemania", "Berlín"},
		{"Portugal", "Lisboa"},
		{"Inglaterra", "Londres"},
		{"Rusia", "Moscú"},
		{"China", "Pekín"},
		{"Japón", "Tokio"},
		{"Noruega", "Oslo"},
	};
    public CapitalesPage()
	{
		InitializeComponent();
		Preguntar(this, EventArgs.Empty);
    }

	public void Preguntar(object? sender, EventArgs e)
	{
		var random = new Random();
		var pais = capitales.ElementAt(random.Next(capitales.Count));
		preguntaLabel.Text = $"¿Cuál es la capital de {pais.Key}?";

        // Obtén la respuesta correcta
        var respuestaCorrecta = pais.Value;

        // Obtén tres respuestas incorrectas
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
		int aciertos = 0;
		int fallos = 0;

		if (capitales[pais] == respuesta)
		{
			DisplayAlert("Correcto", "¡Has acertado!", "Siguiente");
			aciertos++;
			aciertoLabel.Text = $"Aciertos: {aciertos.ToString()}";
        }
		else
		{
			DisplayAlert("Incorrecto", $"La capital de {pais} es {capitales[pais]}.", "Siguiente");
			fallos++;
			falloLabel.Text = $"Fallos: {fallos.ToString()}";
        }
		Preguntar(this, EventArgs.Empty);
    }
}
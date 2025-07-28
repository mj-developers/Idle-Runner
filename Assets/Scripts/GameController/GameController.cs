using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;

[System.Serializable]
public class DatosJugador
{
    public int monedas = 0;
}

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public int Monedas => datosJugador.monedas;
    public TextMeshProUGUI pointsText;
    public GameObject firePrefab;

    private DatosJugador datosJugador;
    private string rutaArchivo;

    private void Start()
    {
        StartCoroutine(GenerarColeccionable()); 
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);  
            return;
        }

        rutaArchivo = Path.Combine(Application.persistentDataPath, "datos" ,"datos.json");
        CargarDatos();
    }

    public void AnadirColeccionable(int cantidad)
    {
        datosJugador.monedas += cantidad;
        ActualizarTexto();
        GuardarDatos();
    } 

    private void GuardarDatos()
    {
        string json = JsonUtility.ToJson(datosJugador, true);
        string directorio = Path.GetDirectoryName(rutaArchivo);
        if (!Directory.Exists(directorio))
        {
            Directory.CreateDirectory(directorio);
        }
        File.WriteAllText(rutaArchivo, json);
    }

    private void CargarDatos()
    {
        if (File.Exists(rutaArchivo))
        {
            string json = File.ReadAllText(rutaArchivo);
            datosJugador = JsonUtility.FromJson<DatosJugador>(json);
        }
        else
        {
            datosJugador = new DatosJugador();
        }
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        pointsText.text = $"{datosJugador.monedas}";
    }

    private IEnumerator GenerarColeccionable()
    { 
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 1f));
            Instantiate(firePrefab, new Vector3(9.3f, Random.Range(-3.5f, 0.25f), 0f), Quaternion.identity);
        }
    }
}

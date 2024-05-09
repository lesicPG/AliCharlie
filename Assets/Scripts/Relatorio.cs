using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Relatorio : MonoBehaviour
{
    // Start is called before the first frame update
public GameObject painelRelatorio;

    public Text erros, acertos, pontFinal, nomeJogador,
    desa1_1, desa1_2, desa1_3, desa1_4,
    desa2_1, desa2_2, desa2_3, desa2_4,
    desa3_1, desa3_2, desa3_3, desa3_4;

    public void SairRelatorio(){
      painelRelatorio.SetActive(false);
    }

    public void MostrarRelatorio(){
      painelRelatorio.SetActive(true);

      erros.text = PlayerPrefs.GetInt("erros_quiz").ToString();
      acertos.text = PlayerPrefs.GetInt("acertos_quiz").ToString();
      pontFinal.text = PlayerPrefs.GetInt("pontuacao_final").ToString();
      nomeJogador.text = PlayerPrefs.GetString("nome_jogador");


    desa1_1.text = PlayerPrefs.GetInt("desa1_1").ToString();
    desa1_2.text = PlayerPrefs.GetInt("desa1_2").ToString();
    desa1_3.text = PlayerPrefs.GetInt("desa1_3").ToString();
    desa1_4.text = PlayerPrefs.GetInt("desa1_4").ToString();

    desa2_1.text = PlayerPrefs.GetInt("desa2_1").ToString();
    desa2_2.text = PlayerPrefs.GetInt("desa2_2").ToString();
    desa2_3.text = PlayerPrefs.GetInt("desa2_3").ToString();
    desa2_4.text = PlayerPrefs.GetInt("desa2_4").ToString();

    desa3_1.text = PlayerPrefs.GetInt("desa3_1").ToString();
    desa3_2.text = PlayerPrefs.GetInt("desa3_2").ToString();
    desa3_3.text = PlayerPrefs.GetInt("desa3_3").ToString();
    desa3_4.text = PlayerPrefs.GetInt("desa3_4").ToString();


    }
}

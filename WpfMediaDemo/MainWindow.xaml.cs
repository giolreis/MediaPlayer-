using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WpfMediaDemo
{
  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Código do botão Play
        private void b1_Click(object sender, RoutedEventArgs e)
        {
            MediaState ms = MediaState.Play;
            // Iniciar o vídeo usando a propriedade LoadedBehavior
            me.LoadedBehavior = ms;
        }

        // Código do botão Pause
        private void b2_Click(object sender, RoutedEventArgs e)
        {
            // Pausar o elemento de mídia (me) usando a mesma propriedade LoadedBehavior
            MediaState uc = MediaState.Pause;
            me.LoadedBehavior = uc;
        }

        // Código do botão Stop
        private void b3_Click(object sender, RoutedEventArgs e)
        {
            // Parar o elemento de mídia em execução usando a mesma propriedade LoadedBehavior
            me.LoadedBehavior = MediaState.Stop;
        }

        // Código do botão Exit
        private void b4_Click(object sender, RoutedEventArgs e)
        {
            // Usar o método estático Exit() da classe Environment para sair da aplicação
            // Parte do código finalizada. Apenas construa e depure o projeto. Agora vou mostrar.
            Environment.Exit(0);
        }

        // Código do botão Browse
        private void b5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog fd = new OpenFileDialog();
                // Definir os filtros
                fd.Filter = "MP3 Files (*.mp3)|*.mp3|MP4 File (*.mp4)|*.mp4|3GP File (*.3gp)|*.3gp|Audio File (*.wma)|*.wma|MOV File (*.mov)|*.mov|AVI File (*.avi)|*.avi|Flash Video(*.flv)|*.flv|Video File (*.wmv)|*.wmv|MPEG-2 File (*.mpeg)|*.mpeg|WebM Video (*.webm)|*.webm|All files (*.*)|*.*";
                // Definir o diretório inicial (opcional)
                fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                // Exibir a janela de diálogo
                fd.ShowDialog();
                // Obter o caminho do arquivo de vídeo/áudio selecionado e armazená-lo em uma variável de string
                string filename = fd.FileName;
                if (filename != "")
                {
                    // Exibir o caminho selecionado do vídeo/áudio no TextBox chamado "tb"
                    tb.Text = filename;
                    // Escrever o código para reproduzir a mídia
                    Uri u = new Uri(filename);
                    // Definir esse objeto URI no elemento de mídia
                    me.Source = u;
                    // Definir o volume (opcional)
                    me.Volume = 100.5;
                    // Iniciar o vídeo usando a propriedade LoadedBehavior
                    MediaState opt = MediaState.Play;
                    me.LoadedBehavior = opt;

                    if (System.IO.Path.GetExtension(filename).Equals(".mp3", StringComparison.OrdinalIgnoreCase))
                    {
                        // Exibir a imagem
                        image.Source = new BitmapImage(new Uri("C:\\Users\\Giovani\\Documents\\WpfMediaPlayer\\image1.png"));
                        image.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        // Ocultar a imagem
                        image.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Nenhuma seleção", "Vazio");
                }
            }
            catch (Exception e1)
            {
                System.Console.WriteLine("Erro: " + e1.Message);
            }
        }

        // Retroceder o vídeo em 5 segundos
        private void SkipBackward1()
        {
            if (me.Position - TimeSpan.FromSeconds(5) >= TimeSpan.Zero)
            {
                me.Position -= TimeSpan.FromSeconds(5);
            }
        }

        // Avançar o vídeo em 5 segundos
        private void SkipForward1()
        {
            if (me.Position + TimeSpan.FromSeconds(5) <= me.NaturalDuration)
            {
                me.Position += TimeSpan.FromSeconds(5);
            }
        }

        // Diminuir o volume
        private void DecreaseVolume1()
        {
            if (me.Volume > 0.0)
            {
                me.Volume -= 0.1;
            }
        }

        // Aumentar o volume
        private void IncreaseVolume1()
        {
            if (me.Volume < 1.0)
            {
                me.Volume += 0.1;
            }
        }

        // Evento window_loaded: chamado automaticamente quando a aplicação é executada pela primeira vez
        // Isso será útil para a parte de pré-processamento. Aqui o vídeo será reproduzido automaticamente ao executar a aplicação
        // Por isso, criei esse evento em vez do evento de botão
        string videoURL = @"C:\Users\Krishna\Desktop\videos\morning1.mp4";

        // Aumentar volume
        private void IncreaseVolume()
        {
            if (me.Volume < 1.0)
            {
                me.Volume += 0.1;
            }
        }

        // Diminuir volume
        private void DecreaseVolume()
        {
            if (me.Volume > 0.0)
            {
                me.Volume -= 0.1;
            }
        }

        // Avançar vídeo em 5 segundos
        private void SkipForward()
        {
            if (me.Position + TimeSpan.FromSeconds(5) <= me.NaturalDuration)
            {
                me.Position += TimeSpan.FromSeconds(5);
            }
        }

        // Retroceder vídeo em 5 segundos
        private void SkipBackward()
        {
            if (me.Position - TimeSpan.FromSeconds(5) >= TimeSpan.Zero)
            {
                me.Position -= TimeSpan.FromSeconds(5);
            }
        }

  

        // Avançar vídeo em 5 segundos (botão b8)
        private void b8_Click(object sender, RoutedEventArgs e)
        {
            SkipForward();
        }

        // Retroceder vídeo em 5 segundos (botão b9)
        private void b9_Click(object sender, RoutedEventArgs e)
        {
            SkipBackward();
        }

        private void window_loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Criar objeto URI porque o MediaElement não suporta diretamente a URL do vídeo
                Uri obj = new Uri(videoURL);
                // Definir a URL do vídeo local via URI e anexar esse objeto Uri ao MediaElement usando sua propriedade Source
                me.Source = obj;
                // Agora a URL foi definida com sucesso no MediaElement. O próximo passo é reproduzir o Media Element
                // Isso é feito pela classe MediaState
                MediaState opt = MediaState.Play;
                // Agora anexe esse estado de reprodução ao MediaElement usando sua propriedade LoadedBehavior
                me.LoadedBehavior = opt;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Mensagem de erro: " + ex.Message);
            }
        }
    }
}


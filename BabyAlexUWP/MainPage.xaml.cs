using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BabyAlexUWP
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
      MediaElement mediaElement = new MediaElement();
      var synth = new SpeechSynthesizer();
      SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync((string)Hello.Content);
      mediaElement.SetSource(stream, stream.ContentType);
      mediaElement.Play();
    }
  }
}

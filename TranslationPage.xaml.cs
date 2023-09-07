using System;
using Microsoft.Maui.Controls;

namespace AIService
{
    public partial class TranslationPage : ContentPage
    {
        private TranslationService translationService = new TranslationService();
        private string targetLanguage = "en";
        public TranslationPage()
        {
            InitializeComponent();
        }

        private async void TranslateButton_Clicked(object sender, EventArgs e)
        {
            string textToTranslate = textToTranslateEditor.Text;
            string sourceLanguage = "en"; // Default source language

            if (!string.IsNullOrWhiteSpace(textToTranslate) && !string.IsNullOrWhiteSpace(sourceLanguage) && !string.IsNullOrWhiteSpace(targetLanguage))
            {
                string translation = await translationService.TranslateAsync(textToTranslate, sourceLanguage, targetLanguage);

                translationResultLabel.Text = translation;
            }
            else
            {
                translationResultLabel.Text = "Please fill in all fields.";
            }
        }

        private async void TranslateInReverseButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                string translatedText = translationResultLabel.Text;
                string originalTargetLanguage = "fr";
                string reverseTranslation = await translationService.TranslateAsync(translatedText, originalTargetLanguage, "en");

                reverseTranslationLabel.Text = reverseTranslation;
            }
            catch (Exception ex)
            {

            }
        }

        private Image selectedFlag = null;
        private Frame selectedFlagFrame = null;
        private void french_Tapped(object sender, EventArgs e)
        {
            if (selectedFlag != null)
            {
                selectedFlag.Style = (Style)Resources["UnselectedFlagStyle"];
            }

            targetLanguage = "fr";

            selectedFlag = (Image)sender;
            selectedFlag.Style = (Style)Resources["SelectedFlagStyle"];
        }
        private void dutch_Tapped(object sender, EventArgs e)
        {
            if (selectedFlag != null)
            {
                selectedFlag.Style = (Style)Resources["UnselectedFlagStyle"];
            }

            targetLanguage = "nl";

            selectedFlag = (Image)sender;
            selectedFlag.Style = (Style)Resources["SelectedFlagStyle"];
        }

        private void russia_Tapped(object sender, EventArgs e)
        {
            if (selectedFlag != null)
            {
                selectedFlag.Style = (Style)Resources["UnselectedFlagStyle"];
            }

            targetLanguage = "ru";

            selectedFlag = (Image)sender;
            selectedFlag.Style = (Style)Resources["SelectedFlagStyle"];
        }

        private void spain_Tapped(object sender, EventArgs e)
        {
            if (selectedFlag != null)
            {
                selectedFlag.Style = (Style)Resources["UnselectedFlagStyle"];
            }

            targetLanguage = "es";

            selectedFlag = (Image)sender;
            selectedFlag.Style = (Style)Resources["SelectedFlagStyle"];
        }

        private void italy_Tapped(object sender, EventArgs e)
        {
            if (selectedFlag != null)
            {
                selectedFlag.Style = (Style)Resources["UnselectedFlagStyle"];
            }

            targetLanguage = "it";

            selectedFlag = (Image)sender;
            selectedFlag.Style = (Style)Resources["SelectedFlagStyle"];
        }


    }
}

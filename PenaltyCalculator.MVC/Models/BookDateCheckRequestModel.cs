using System;
using System.ComponentModel.DataAnnotations;

namespace PenaltyCalculator.MVC.Models
{
    public class BookDateCheckRequestModel
    {
        [Required(ErrorMessage = "Kitap Çıkış Tarihini Girin")]
        [DataType(DataType.Date)]
        public DateTime CheckoutDate { get; set; }
        [Required(ErrorMessage = "Kitap İade Tarihini Girin")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
        [Required(ErrorMessage = "Ülke Seçiniz")]
        public CountryViewModel Country { get; set; }
    }
}
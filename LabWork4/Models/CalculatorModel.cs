using System.ComponentModel.DataAnnotations;

namespace LabWork4.Models
{
	public class CalculatorModel
	{
		[Required(ErrorMessage = "Поле обязательно для заполнения.")]
		public ushort operandA { set; get; }

		[Required(ErrorMessage = "Поле обязательно для заполнения.")]
		public decimal operandB { set; get; }

		public string operation { set; get; }
		public decimal result { set; get; }


		public void Sum()
		{
			this.result = this.operandA + this.operandB;
		}
		public void Sub()
		{
			this.result = this.operandA - this.operandB;
		}
		public void Mul()
		{
			this.result = this.operandA * this.operandB;
		}
		public void Div()
		{
			this.result = this.operandA / this.operandB;
		}
	}
}

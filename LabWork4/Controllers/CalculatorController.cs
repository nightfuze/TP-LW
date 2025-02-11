using LabWork4.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabWork4.Controllers
{
	public class CalculatorController : Controller
	{
		// GET: CalculatorController
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(CalculatorModel calc, string action)
		{
			if (action == "calculate")
			{
				switch (calc.operation)
				{
					case "+":
						calc.Sum();
						break;
					case "-":
						calc.Sub();
						break;
					case "*":
						calc.Mul();
						break;
					case "/":
						if (calc.operandB == 0)
						{
							ViewBag.MessageError = "Ошибка: деление на ноль";
						}
						else
						{
							calc.Div();
						}
						break;
					default:
						break;
				}

				var result = ViewBag.MessageError != null ? ViewBag.MessageError : calc.result;
				string operationString = $"{calc.operandA} {calc.operation} {calc.operandB} = {result}";

				int equalsIndex = operationString.LastIndexOf('=');
				if (equalsIndex != -1)
				{
					string beforeEquals = operationString.Substring(0, equalsIndex);
					string afterEquals = operationString.Substring(equalsIndex + 1);
					operationString = $"{beforeEquals} равно {afterEquals}";
				}

				HttpContext.Session.SetString("OpView", operationString);


				return View("Index", calc);
			}

			ModelState.Clear();
			return View();
		}

		public ActionResult OperationView()
		{
			var opView = HttpContext.Session.GetString("OpView");

			if (opView != null)
			{
				ViewBag.OpView = opView;
			}
			return View();
		}

		// GET: CalculatorController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: CalculatorController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CalculatorController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: CalculatorController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: CalculatorController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: CalculatorController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: CalculatorController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}

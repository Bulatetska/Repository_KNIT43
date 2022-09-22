{
	bool boolVariable = true;
	if (boolVariable) {
		System.Console.WriteLine("boolVariable = true; --- Istyna!");
	}
	else {
		System.Console.WriteLine("boolVariable = false; Hybno!");
	}
	System.Console.WriteLine();

	boolVariable = false;
	if (boolVariable) {
		System.Console.WriteLine("boolVariable = true; --- Istyna!");
	}
	else {
		System.Console.WriteLine("boolVariable = false; Hybno!");
	}
	System.Console.WriteLine();

	boolVariable = 2 < 4;
	if (boolVariable) {
		System.Console.WriteLine("boolVariable = 2 < 4; --- Istyna!");
	}
	else {
		System.Console.WriteLine("boolVariable = 2 < 4; Hybno!");
	}
	System.Console.WriteLine();

	if (10 != 100) {
		System.Console.WriteLine("10 != 100 ! Rizni chysla!");
	}
	System.Console.WriteLine();

	System.Console.ReadLine();
}
/* code goes here */
var	isCanadian	=	true;

var tax = function	taxRate()	{
		//	remember : variables	defined	outside	of	a	function	have	global	scope
		if	(isCanadian)	{
						return	0.05;
		}	else	{
						return	0.0;
		}
}
function	calculateTax(amount,	tax)	{
    return	amount	*	tax();
}
var tax = function	calculateTotal(price,	quantity)	{
    var	amount	=	price	*	quantity;				
    return	amount	+	calculateTax(amount,	function	()	{
                    if	(isCanadian)	{
                                    return	0.05;
                    }	else	{
                                    return	0.0;
                    }
    });
}
function	calculateTotal(price,	quantity)	{
		return	(price	*	quantity)	+	calculateTax(price	*	quantity);
}
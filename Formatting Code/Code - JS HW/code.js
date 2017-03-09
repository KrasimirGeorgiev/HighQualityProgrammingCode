var b = navigator.appName,
addScroll = false,
off = 0,
txt = "",
pX = 0,
pY = 0;

if ((navigator.userAgent.indexOf('MSIE 5') > 0) ||
		(navigator.userAgent.indexOf('MSIE 6')) > 0) {
	addScroll = true;
}

document.onmousemove = mouseMove;

if (b === "Netscape") {
	document.captureEvents(Event.MOUSEMOVE);
}

function mouseMove(evn) {
	if (b === "Netscape") {
		pX = evn.pageX - 5;
		pY = evn.pageY;

		if (document.layers.ToolTip.visibility === 'show') {
			popTip();
		}

	} else {
		pX = event.x - 5;
		pY = event.y;

		if (document.all.ToolTip.style.visibility === 'visible') {
			popTip();
		}
	}
}

function popTip() {
	var theLayer;
	if (b === "Netscape") {
		//theLayer = eval('document.layers.ToolTip');
		theLayer = document.layers.ToolTip;

		if ((pX + 120) > window.innerWidth) {
			pX = window.innerWidth - 150;
		}

		theLayer.left = pX + 10;
		theLayer.top = pY + 15;
		theLayer.visibility = 'show';

	} else {
		//theLayer = eval('document.all.ToolTip');
		theLayer = evaldocument.all.ToolTip;

		if (theLayer) {
			pX = event.x - 5;
			pY = event.y;

			if (addScroll) {
				pX += document.body.scrollLeft;
				pY += document.body.scrollTop;
			}

			if ((pX + 120) > document.body.clientWidth) {
				pX -= 150;
			}

			theLayer.style.pixelLeft = pX + 10;
			theLayer.style.pixelTop = pY + 15;
			theLayer.style.visibility = 'visible';
		}
	}
}

function hideTip() {
	var args = HideTip.arguments;

	if (b === "Netscape") {
		document.layers.ToolTip.visibility = 'hide';
	} else {
		document.all.ToolTip.style.visibility = 'hidden';
	}
}

function hideMenu1() {
	if (b === "Netscape") {
		document.layers.menu1.visibility = 'hide';
	} else {
		document.all.menu1.style.visibility = 'hidden';
	}
}

function showMenu1() {
	var theLayer;

	if (b === "Netscape") {
		//theLayer = eval('document.layers[\'menu1\']');
		theLayer = document.layers.menu1;
		theLayer.visibility = 'show';
	} else {
		// theLayer = eval('document.all[\'menu1\']');
		theLayer = document.all.menu1;
		theLayer.style.visibility = 'visible';
	}
}

function hideMenu2() {
	if (b === "Netscape") {
		document.layers.menu2.visibility = 'hide';
	} else {
		document.all.menu2.style.visibility = 'hidden';
	}
}

function showMenu2() {
	var theLayer;

	if (b === "Netscape") {
		// theLayer = eval('document.layers[\'menu2\']');
		theLayer = document.layers.menu2;
		theLayer.visibility = 'show';
	} else {
		// theLayer = eval('document.all[\'menu2\']');
		theLayer = document.all.menu2;
		theLayer.style.visibility = 'visible';
	}
}

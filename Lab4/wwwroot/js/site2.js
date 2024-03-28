function gizle() {
    var btn = document.getElementById("gizle")
    btn.style.display="none"    
  }

  function goster() {
    var btn = document.getElementById("gizle");
    btn.style.display = "block";
  }

  function toggleForm() {
    var form = document.getElementById("myForm");
    form.style.display = form.style.display === "none" ? "block" : "none";
  }

  function calculateSum() {
    var input1 = parseFloat(document.getElementById("input1").value);
    var input2 = parseFloat(document.getElementById("input2").value);

    if (isNaN(input1) || isNaN(input2)) {
      alert("Lütfen geçerli sayılar girin.");
      return;
    }
    
      var sum = input1 + input2;
      document.getElementById("result").innerText = "Toplam: " + sum;
      
  }
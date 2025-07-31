(function(){
  const colors = ["#1f77b4", "#ff7f0e", "#2ca02c", "#d62728", "#9467bd"];
  const input = document.getElementById("input-data");
  const btn = document.getElementById("btn-update");
  const errorMsg = document.getElementById("error-msg");
  const chartDiv = document.getElementById("chart");

  btn.addEventListener("click", updateChartData);

  function updateChartData() {
    errorMsg.textContent = "";
    const result = validateData(input.value.trim());

    if (!result.isValid) {
      errorMsg.textContent = result.error;
      return;
    }

    console.log('values', result.value);
    showChart(result.value);
  }

  function validateData(input){
    if (!input) {
      return { isValid: false, error: "El campo no puede estar vacío.", value: null };
    }

    const partsOfInput = input.split(",").map(s => s.trim());
    const isAllNumbers = partsOfInput.every(s => /^[0-9]+$/.test(s));

    if (!isAllNumbers) {
      return { isValid: false, error: "Sólo enteros positivos separados por coma.",  value: null };
    }

    const values = partsOfInput.map(s => +s);
    console.log('values validate', values);

    return { isValid: true, error: null, value: values };
  }

  function showChart(values) {
    const width = 600, height = 400;
    const margin = { top: 20, right: 30, bottom: 30, left: 40 };
    
    chartDiv.innerHTML = "";

    const svg = d3.select(chartDiv)
      .append("svg")
      .attr("width", width)
      .attr("height", height);

    const xScale = d3.scaleLinear()
      .domain([0, d3.max(values)])
      .range([margin.left, width - margin.right]);

    const yScale = d3.scaleBand()
      .domain(d3.range(values.length))
      .range([margin.top, height - margin.bottom])
      .padding(0.1);

    svg.append("g")
      .selectAll("rect")
      .data(values)
      .join("rect")
      .attr("class", "bar")
      .attr("x", xScale(0))
      .attr("y", (d, i) => yScale(i))
      .attr("width", d => xScale(d) - xScale(0))
      .attr("height", yScale.bandwidth())
      .attr("fill", (d, i) => colors[i % colors.length]);

      svg.append("g")
        .selectAll("text")
        .data(values)
        .join("text")
        .attr("x", d => xScale(d) - 5)
        .attr("y", (d, i) => yScale(i) + yScale.bandwidth() / 2 + 4)
        .text(d => d)
        .attr("fill", "white")
        .attr("text-anchor", "end")
        .attr("font-size", "12px");

  }

})();

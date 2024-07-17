const personalTab = document.getElementById("SEW-tab-personal");
const commonTab = document.getElementById("SEW-tab-common");

const personalTable = document.getElementById("SEW-table-personal");
const commonTable = document.getElementById("SEW-table-common");

const handleToggleTab = (tab) => {
  if (tab == "1") {
    personalTab.classList.add("SEW-tab-active");
    commonTab.classList.remove("SEW-tab-active");

    commonTable.classList.add("hidden");
    personalTable.classList.remove("hidden");
  }

  if (tab == "2") {
    commonTab.classList.add("SEW-tab-active");
    personalTab.classList.remove("SEW-tab-active");

    personalTable.classList.add("hidden");
    commonTable.classList.remove("hidden");
  }
};

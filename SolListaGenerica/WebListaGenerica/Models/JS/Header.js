const ELEMENTS = {
  MAIN_SEARCH_ELEMENT: "#main_search_element",
  ACTION_EXPAND_ELEMENT: ".action-expand",
  ACTION_COLLAPSE_ELEMENT: ".action-collapse"
};

let isExpanded = false;

const ToggleSearchElement = document.querySelector(
  ELEMENTS.ACTION_EXPAND_ELEMENT
);

const SearchIconCircleElement = document.querySelector(
  ELEMENTS.MAIN_SEARCH_ELEMENT
);

ToggleSearchElement.onclick = () => {
  searchIconExpandToggle();
};

const searchIconExpandToggle = () => {
  isExpanded = !isExpanded;

  if (isExpanded) {
    SearchIconCircleElement.classList.add("expand");

    watchForCollapseAction();
  } else {
    SearchIconCircleElement.classList.remove("expand");
  }
};

const watchForCollapseAction = () => {
  const ToggleSearchElement = document.querySelector(
    ELEMENTS.ACTION_COLLAPSE_ELEMENT
  );

  ToggleSearchElement.onclick = () => {
    searchIconExpandToggle();
  };
};
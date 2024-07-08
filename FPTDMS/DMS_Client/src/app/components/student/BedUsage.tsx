

const BedUsage = () => {
  return (
    <>
      <div id="content-body" className="content-body">
        <div className="container-fluid my-container">
          <div>
            <h1 className="big-title">Resident history</h1>
            <div className="flex flex-col items-center" style={{marginTop: "24px"}}>
              <img
                className="flex justify-center"
                style={{maxWidth: "50%", height: "auto", minWidth: "300px"}}
                src="/Content/images/FrogFind.png"
                alt="Alternate Text"
              />
              <p className="no-record-found">No record found!</p>
            </div>
          </div>
        </div>
        <div
          style={{
            width: "100%",
            height: "20px",
            backgroundColor: "aliceblue",
            textAlign: "center"
          }}
        >
          <span>Version : 2.3.0.2 | Online: 1691</span>
        </div>
      </div>
    </>
  )
}
export default BedUsage

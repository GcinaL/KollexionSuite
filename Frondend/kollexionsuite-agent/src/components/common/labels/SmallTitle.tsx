

function SmallTitle({ title, margin}: { title: string; margin?:string}){
  return (
    <div className={margin? margin : "mb-2"}>
    <h6 className='fs-16 fw-semibold'>{title}</h6>
    </div>
  )
}

export default SmallTitle
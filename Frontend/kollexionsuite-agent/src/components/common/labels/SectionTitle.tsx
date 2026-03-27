export default function SectionTitle({ title, icon }: { title: string, icon?: string }) {
  return (
    <div className='row'>
        <div className='col-12'>
            <label className="mb-3 mt-2 fs-16 capitalize d-flex align-items-center">
                <i className={`${icon} me-2`}></i>
                <span>{title}</span>
            </label>
        </div>
    </div>
  )
}
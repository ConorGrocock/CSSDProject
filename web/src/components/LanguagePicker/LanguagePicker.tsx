import {useTranslation} from "react-i18next";
import {useEffect, useState} from "react";

export interface LanguagePickerProps {
}

function LanguagePicker(props: LanguagePickerProps) {
    const { i18n } = useTranslation();
    const [lngs, setLngs] = useState<any>({ en: { nativeName: 'English' }});
    useEffect(() => {
        i18n.services.backendConnector.backend.getLanguages((err: any, ret: any) => {
            if (err) return // TODO: handle err...
            setLngs(ret);
        });
    }, []);

    return <div style={{
        position: 'fixed',
        top: 0,
        right: 0,
        zIndex: 100,
        backgroundColor: 'white',
        padding: '10px',
        borderRadius: '5px',
        boxShadow: '0px 0px 5px #ccc',
    }}>
        {Object.keys(lngs).map((lng: string) => (
            <button key={lng} style={{ fontWeight: i18n.language === lng ? 'bold' : 'normal' }} type="submit" onClick={() => i18n.changeLanguage(lng)}>
                {lngs[lng].nativeName}
            </button>
        ))}
    </div>
}

export default LanguagePicker;